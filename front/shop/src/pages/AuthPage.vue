<template>
    <div class="auth-page">
      <AuthForm :onAuthSuccess="handleAuthSuccess" />
    </div>
  </template>
  
  <script>
  import AuthForm from '../components/AuthForm.vue';
  
  export default {
    components: { AuthForm },
    methods: {
      handleAuthSuccess() {
        this.$router.push('/main');
      },
    },
  };
  </script>
  
  <style scoped>
  .auth-page {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    background-color: #f9f9f9;
  }
  </style>