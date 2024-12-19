import { createRouter, createWebHistory } from 'vue-router';
import AuthPage from '../pages/AuthPage.vue';
import MainPage from '../pages/MainPage.vue';

const routes = [
  { path: '/', redirect: '/auth' },
  { path: '/auth', name: 'Auth', component: AuthPage },
  { path: '/main', name: 'Main', component: MainPage },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;