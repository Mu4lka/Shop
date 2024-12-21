<template>
  <div class="products">
    <h2>Доступные товары</h2>
    <div class="product-cards">
      <div v-for="product in products" :key="product.id" class="product-card"
        :class="{ selected: selectedQuantity[product.id] > 0 }" @click="selectProduct(product.id)">
        <h3>{{ product.title }}</h3>
        <p><strong>Описание:</strong> {{ product.description }}</p>
        <p><strong>Количество в наличии:</strong> {{ product.availableQuantity }}</p>
        <p><strong>Артикул:</strong> {{ product.sku }}</p>
        <p>
          <strong>Цена:</strong>
          {{ product.price.amount }} {{ product.price.currency }}
        </p>

        <!-- Кнопки изменения количества -->
        <div v-if="selectedQuantity[product.id] > 0" class="quantity-selector" @click.stop>
          <button @click="changeQuantity(product.id, -1)" :disabled="selectedQuantity[product.id] <= 0">-</button>
          <span>{{ selectedQuantity[product.id] }}</span>
          <button @click="changeQuantity(product.id, 1)"
            :disabled="selectedQuantity[product.id] >= product.availableQuantity">+</button>
        </div>
      </div>
    </div>

    <!-- Зеленая кнопка для создания заказа -->
    <button v-if="hasSelectedProducts" class="order-button fixed-bottom" @click="openOrderModal">
      Создать заказ
    </button>

    <!-- Модальное окно подтверждения заказа -->
    <div v-if="showModal" class="modal">
      <div class="modal-content">
        <h3>Подтверждение заказа</h3>
        <ul>
          <li v-for="product in selectedProducts" :key="product.id">
            {{ product.title }}: {{ product.quantity }} шт.
          </li>
        </ul>
        <div class="modal-buttons">
          <button @click="confirmOrder">Подтвердить</button>
          <button @click="closeOrderModal">Отмена</button>
        </div>
      </div>
    </div>

    <p v-if="loading">Загрузка...</p>
    <p v-if="error">{{ error }}</p>
  </div>
</template>

<script>
import { getProducts } from "@/services/productsService";
import { createOrder } from "@/services/ordersService";

export default {
  name: "AvailableProducts",
  data() {
    return {
      products: [],
      loading: false,
      error: null,
      selectedQuantity: {}, // Хранение выбранного количества для каждого продукта
      showModal: false,
    };
  },
  computed: {
    selectedProducts() {
      return Object.entries(this.selectedQuantity)
        .filter(([, quantity]) => quantity > 0)
        .map(([productId, quantity]) => ({
          id: productId,
          title: this.getProductTitle(productId),
          quantity,
        }));
    },
    hasSelectedProducts() {
      return Object.values(this.selectedQuantity).some((quantity) => quantity > 0);
    },
  },
  async mounted() {
    this.loading = true;
    try {
      this.products = await getProducts();
    } catch (err) {
      this.error = `Ошибка загрузки продуктов: ${err.message}`;
    } finally {
      this.loading = false;
    }
  },
  methods: {
    selectProduct(productId) {
      if (!this.selectedQuantity[productId]) {
        this.selectedQuantity[productId] = 1; // Инициализация количества
      } else {
        this.selectedQuantity[productId] = 0; // Сброс количества
      }
    },
    changeQuantity(productId, delta) {
      const newQuantity = (this.selectedQuantity[productId] || 0) + delta;
      if (newQuantity >= 0 && newQuantity <= this.getProductAvailableQuantity(productId)) {
        this.selectedQuantity[productId] = newQuantity; // Прямое присваивание
      }
    },
    getProductAvailableQuantity(productId) {
      const product = this.products.find((p) => p.id === productId);
      return product ? product.availableQuantity : 0;
    },
    getProductTitle(productId) {
      const product = this.products.find((p) => p.id === productId);
      return product ? product.title : "";
    },
    openOrderModal() {
      this.showModal = true;
    },
    closeOrderModal() {
      this.showModal = false;
    },
    async confirmOrder() {
      this.showModal = false;
      const items = Object.entries(this.selectedQuantity)
        .map(([productId, quantity]) => ({
          productId: productId,
          count: quantity,
        }));
      const request = {
        items: items
      }
      console.log(request);
      try {
        await createOrder(request);
        alert("Заказ подтвержден! Спасибо за покупку.");
      }
      catch (error) {
        alert(`Ошибка создания заказа: ${error.message}`);
      }
      this.selectedQuantity = {};
    },
  },
};
</script>

<style scoped>
.products {
  padding: 20px;
}

.product-cards {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
  gap: 20px;
}

.product-card {
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 20px;
  background-color: #fff;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  transition: transform 0.2s ease;
  cursor: pointer;
}

.product-card:hover {
  transform: translateY(-5px);
}

.product-card.selected {
  background-color: #e0f7e0;
}

.quantity-selector {
  display: flex;
  align-items: center;
  margin-top: 10px;
}

.quantity-selector button {
  background-color: #4caf50;
  color: white;
  border: none;
  padding: 5px 10px;
  font-size: 1.2rem;
  cursor: pointer;
  margin: 0 5px;
  border-radius: 4px;
}

.quantity-selector button:disabled {
  background-color: #bdbdbd;
  cursor: not-allowed;
}

.quantity-selector span {
  font-size: 1.2rem;
  margin: 0 10px;
}

.order-button {
  background-color: #4caf50;
  color: white;
  border: none;
  padding: 10px 20px;
  font-size: 1rem;
  margin-top: 20px;
  cursor: pointer;
  border-radius: 4px;
}

.fixed-bottom {
  position: fixed;
  bottom: 20px;
  left: 50%;
  transform: translateX(-50%);
  z-index: 1000;
  max-width: 500px;
  padding: 12px 24px;
  font-size: 1.25rem;
  border-radius: 6px;
}

.order-button:hover {
  background-color: #3a863c;
  /* Темнее синий при наведении */
}

.modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal-content {
  background-color: white;
  padding: 20px;
  border-radius: 8px;
  width: 400px;
  text-align: center;
}

.modal-content ul {
  list-style: none;
  padding: 0;
}

.modal-buttons {
  margin-top: 20px;
  display: flex;
  justify-content: space-between;
}

.modal-buttons button {
  background-color: #4caf50;
  color: white;
  border: none;
  padding: 10px 20px;
  font-size: 1rem;
  cursor: pointer;
  border-radius: 4px;
}

.modal-buttons button:nth-child(2) {
  background-color: #f44336;
}
</style>