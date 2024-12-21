<template>
  <div class="auth-form">
    <h2 class="form-title">{{ isLogin ? 'Вход' : 'Регистрация' }}</h2>
    <transition name="fade">
      <form @submit.prevent="handleSubmit" key="form">
        <div class="form-group">
          <label>Email*:</label>
          <input type="email" v-model="email" required />
        </div>
        <div v-if="!isLogin" class="name-group">
          <div class="form-group small">
            <label>Имя*:</label>
            <input type="text" v-model="firstName" required />
          </div>
          <div class="form-group small">
            <label>Фамилия*:</label>
            <input type="text" v-model="surname" required />
          </div>
          <div class="form-group small">
            <label>Отчество:</label>
            <input type="text" v-model="patronymic" />
          </div>
        </div>
        <div v-if="!isLogin" class="form-group">
          <label>Адрес*:</label>
          <input type="text" v-model="address" required />
        </div>
        <div v-if="!isLogin" class="form-group">
          <label>Телефон*:</label>
          <input type="tel" v-model="phoneNumber" required />
        </div>
        <div class="form-group">
          <label>Пароль*:</label>
          <input type="password" v-model="password" required />
        </div>
        <div v-if="!isLogin" class="form-group">
          <label>Подтвердите пароль*:</label>
          <input type="password" v-model="confirmPassword" required />
        </div>
        <button type="submit" class="submit-button">
          {{ isLogin ? 'Войти' : 'Зарегистрироваться' }}
        </button>
      </form>
    </transition>
    <button class="toggle-button" @click="toggleForm">
      {{ isLogin ? 'Нет аккаунта? Регистрация' : 'Уже есть аккаунт? Войти' }}
    </button>
  </div>
</template>

<script>
import { loginUser, registerUser } from '@/services/userService';

export default {
  props: ['onAuthSuccess'],
  data() {
    return {
      isLogin: true,
      email: '',
      password: '',
      firstName: '',
      surname: '',
      patronymic: null,
      address: '',
      phoneNumber: '',
      confirmPassword: '',
    };
  },
  methods: {
    toggleForm() {
      this.isLogin = !this.isLogin;
    },
    async handleSubmit() {
      if (!this.isLogin && this.password !== this.confirmPassword) {
        alert('Пароли не совпадают!');
        return;
      }
      try {
        if (this.isLogin) {
          const response = await loginUser(this.email, this.password);
          localStorage.setItem('authToken', response.data);
          this.onAuthSuccess();
          return;
        } else {
          await registerUser(
            this.email,
            this.firstName,
            this.surname,
            this.patronymic,
            this.address,
            this.phoneNumber,
            this.password
          );
          alert('Вы успешно зарегистрировались');
        }
      } catch (error) {
        alert(`Ошибка: ${error.message}`);
      }
    },
  },
};
</script>

<style scoped>
.auth-form {
  max-width: 500px;
  min-width: 500px;
  margin: 50px auto;
  padding: 30px;
  background: #ffffff;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  font-family: 'Arial', sans-serif;
  box-sizing: border-box; /* Включает padding и border в общую ширину */
}

.form-group {
  margin-bottom: 15px;
  display: flex;
  flex-direction: column;
}

.form-group label {
  margin-bottom: 5px;
  font-weight: bold;
  color: #555;
}

.form-group input {
  width: 100%; /* Ограничение ширины до 100% родителя */
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 14px;
  transition: border 0.2s ease-in-out;
  box-sizing: border-box; /* Корректный учет padding */
}

.form-group input:focus {
  border: 1px solid #007BFF;
  outline: none;
}

.name-group {
  display: flex;
  justify-content: space-between;
  gap: 10px; /* Отступы между элементами */
}

.name-group .form-group {
  flex: 1; /* Равномерное распределение ширины */
}

.submit-button {
  width: 100%;
  padding: 10px;
  font-size: 16px;
  color: #fff;
  background: linear-gradient(45deg, #007BFF, #0056b3);
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background 0.3s ease-in-out;
}

.submit-button:hover {
  background: linear-gradient(45deg, #0056b3, #003580);
}

.toggle-button {
  margin-top: 20px;
  width: 100%;
  background: none;
  border: none;
  font-size: 14px;
  color: #007BFF;
  cursor: pointer;
  text-decoration: underline;
}

.toggle-button:hover {
  color: #0056b3;
}

/* Адаптивные стили для телефонов */
@media (max-width: 768px) {
  .auth-form {
    max-width: 100%;
    min-width: auto;
    margin: 20px;
    padding: 20px;
  }

  .name-group {
    flex-direction: column;
    gap: 0; /* Убираем отступы между элементами */
  }

  .name-group .form-group {
    width: 100%; /* На телефоне каждая строка занимает 100% */
    margin-bottom: 10px; /* Добавляем отступ снизу */
  }
}

@media (max-width: 480px) {
  .auth-form {
    padding: 15px;
  }

  .submit-button {
    font-size: 14px;
    padding: 8px;
  }

  .toggle-button {
    font-size: 12px;
  }
}
</style>
