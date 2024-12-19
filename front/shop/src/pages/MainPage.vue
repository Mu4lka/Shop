<template>
    <div class="main-page">
      <AppHeader @navigate="currentView = $event" />
      <div class="content">
        <AvailableProducts v-if="currentView === 'products'" />
        <UserOrders v-else />
      </div>
    </div>
  </template>
  
  <script>
  import AppHeader from '../components/AppHeader.vue';
  import AvailableProducts from '../components/AvailableProducts.vue';
  import UserOrders from '../components/UserOrders.vue';
  
  export default {
    components: { AppHeader, AvailableProducts, UserOrders },
    data() {
      return {
        currentView: 'products',
      };
    },
  };
  </script>
  
  <style scoped>
  .main-page {
    display: flex;
    flex-direction: column;
  }
  .content {
    padding: 20px;
  }
  </style>