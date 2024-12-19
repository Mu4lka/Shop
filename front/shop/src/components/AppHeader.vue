<template>
  <header class="main-header">
    <nav class="nav">
      <button class="nav-button" @click="$emit('navigate', 'products')">Доступные товары</button>
      <button class="nav-button" @click="$emit('navigate', 'orders')">Мои заказы</button>
      <button class="logout-button" @click="logOut">Выйти</button>
    </nav>
  </header>
</template>

<script>
export default {
  name: 'AppHeader',

  methods: {
    logOut() {
      localStorage.removeItem('authToken');
      this.$router.push('/auth');
    }
  }
};
</script>

<style scoped>
.main-header {
  background-color: #d5d5d5;
  padding: 15px 30px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  border: 1px solid #ddd;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.nav {
  display: flex;
  gap: 20px;
}

.nav-button {
  background-color: #4caf50;
  color: white;
  font-size: 16px;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease, transform 0.3s ease;
}

.nav-button:hover {
  background-color: #3a863c;
  transform: translateY(-2px);
}

.nav-button:focus {
  outline: none;
  box-shadow: 0 0 0 3px rgba(78, 186, 48, 0.5);
}

.logout-button {
  position: absolute;
  top: 15px;
  right: 30px;
  background-color: #4caf50;
  color: white;
  font-size: 16px;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease, transform 0.3s ease;
}

.logout-button:hover {
  background-color: #3a863c;
  transform: translateY(-2px);
}

.logout-button:focus {
  outline: none;
  box-shadow: 0 0 0 3px rgba(78, 186, 48, 0.5);
}

</style>