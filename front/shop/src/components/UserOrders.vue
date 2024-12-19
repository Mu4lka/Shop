<template>
  <div class="orders">
    <h2>Мои заказы</h2>
    <div v-if="orders && orders.length > 0" class="order-list">
      <div v-for="order in orders" :key="order.id" class="order-card">
        <div class="order-header">
          <h3>Заказ {{ order.id }}</h3>
          <div class="order-info">
            <p class="order-date">Дата: {{ formatDate(order.createdAt) }}</p>
            <p class="order-status" :class="getStatusClass(order.status)">
              Статус: {{ getStatusText(order.status) }}
            </p>
          </div>
        </div>
        <div v-if="order.showDetails" class="order-items">
          <h4>Выбранные товары:</h4>
          <ul>
            <li v-for="item in order.items" :key="item.id" class="item">
              <div class="item-details">
                <p class="item-title">{{ item.product.title }}</p>
                <p class="item-count">Кол-во: {{ item.count }}</p>
              </div>
              <p class="item-price">{{ item.price.amount }} {{ item.price.currency }}</p>
            </li>
          </ul>
        </div>
        <button class="toggle-items" @click="toggleOrderDetails(order)">
          {{ order.showDetails ? 'Свернуть товары' : 'Развернуть товары' }}
        </button>
        <div class="order-total">
          <p>Итого: {{ calculateTotal(order.items) }}</p>
        </div>
      </div>
    </div>
    <div v-else>
      <p>Заказы отсутствуют.</p>
    </div>
  </div>
</template>

<script>
import { getMyOrders } from '@/services/ordersService';

export default {
  name: 'UserOrders',
  data() {
    return {
      orders: null, // Изначально пусто
    };
  },
  async mounted() {
    try {
      this.orders = await getMyOrders();
      this.orders.forEach(order => {
        order.showDetails = false; // Добавляем свойство для управления отображением
      });
    } catch (error) {
      console.error('Ошибка загрузки заказов:', error);
      this.orders = []; // Устанавливаем пустой массив в случае ошибки
    }
  },
  methods: {
    formatDate(date) {
      const options = { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit' };
      return new Date(date).toLocaleDateString('ru-RU', options);
    },
    getStatusText(status) {
      const statuses = {
        0: 'Создан',
        1: 'Отправлен',
        2: 'В пункте выдачи',
        3: 'Доставлен',
      };
      return statuses[status] || 'Неизвестный статус';
    },
    getStatusClass(status) {
      const classes = {
        0: 'status-pending',
        1: 'status-shipped',
        2: 'status-delivered',
      };
      return classes[status] || '';
    },
    calculateTotal(items) {
      return items.reduce((sum, item) => sum + item.price.amount * item.count, 0).toFixed(2) + ' USD';
    },
    toggleOrderDetails(order) {
      order.showDetails = !order.showDetails;
    },
  },
};
</script>

<style scoped>
.orders {
  padding: 20px;
  font-family: 'Arial', sans-serif;
}
.order-list {
  display: flex;
  flex-direction: column;
  gap: 20px;
  align-items: flex-start; /* Выравнивание заказов по левому краю */
}
.order-card {
  border: 1px solid #ddd;
  border-radius: 12px;
  padding: 20px;
  background-color: #ffffff;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  width: 50%;
  transition: transform 0.2s ease-in-out, box-shadow 0.2s ease-in-out;
}
.order-card:hover {
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
}
.order-header {
  margin-bottom: 16px;
}
.order-header h3 {
  font-size: 18px;
  color: #333;
}
.order-info {
  display: flex;
  gap: 16px; /* Отступы между информацией */
  flex: auto;
  flex-wrap: wrap; /* Перенос информации на следующую строку, если не хватает места */
}
.order-date {
  font-size: 14px;
  color: #777;
}
.order-status {
  font-size: 14px;
  font-weight: bold;
  border-radius: 4px;
  padding: 4px 8px;
}
.status-pending {
  color: #856404;
  background-color: #fff3cd;
}
.status-shipped {
  color: #004085;
  background-color: #cce5ff;
}
.status-delivered {
  color: #155724;
  background-color: #d4edda;
}
.toggle-items {
  background-color: #007bff;
  color: #fff;
  border: none;
  border-radius: 8px;
  padding: 8px 16px;
  cursor: pointer;
  font-size: 14px;
  display: block;
  margin: 16px auto 0;
  transition: background-color 0.3s ease;
}
.toggle-items:hover {
  background-color: #0056b3;
}
.order-items {
  margin-bottom: 16px;
  border-top: 1px solid #eee;
  padding-top: 16px;
}
.item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 8px;
  padding-bottom: 8px;
  border-bottom: 1px solid #eee;
}
.item-title {
  font-size: 16px;
  color: #333;
}
.item-count {
  font-size: 14px;
  color: #666;
}
.item-price {
  font-size: 16px;
  font-weight: bold;
  color: #000;
}
.order-total {
  font-size: 16px;
  font-weight: bold;
  text-align: right;
  color: #333;
}
</style>
