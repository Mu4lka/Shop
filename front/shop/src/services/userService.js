import apiClient from "./apiClient";

const USERS_API_ROUTE = '/api/v1/users';

/**
 * Логин пользователя.
 * @param {string} email - Электронная почта пользователя.
 * @param {string} password - Пароль пользователя.
 * @returns {Promise<Object>} Ответ.
 */
export async function loginUser(email, password) {
  try {
    const response = await apiClient.post(`${USERS_API_ROUTE}/login`, { email, password });
    return response;
  } catch (error) {
    throw new Error(error.response?.data || error.message);
  }
}

/**
 * Регистрация нового пользователя.
 * @param {string} email - Электронная почта пользователя.
 * @param {string} firstName - Имя пользователя.
 * @param {string} surname - Фамилия пользователя.
 * @param {string?} patronymic - Отчество пользователя.
 * @param {string} address - Адрес пользователя.
 * @param {string} phoneNumber - Телефон пользователя.
 * @param {string} password - Пароль пользователя.
 * @returns {Promise<Object>} Ответ;
 */
export async function registerUser(email, firstName, surname, patronymic, address, phoneNumber, password) {
  try {
    const response = await apiClient.post(`${USERS_API_ROUTE}/register`, { email, firstName, surname, patronymic, address, phoneNumber, password });
    return response;
  } catch (error) {
    throw new Error(error.response?.data || error.message);
  }
}