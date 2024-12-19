import apiClient from "./apiClient";

const PRODUCTS_API_ROUTE = '/api/v1/products';

export async function getProducts() {
    try {
        const response = await apiClient.get(PRODUCTS_API_ROUTE);
        return response.data.data;
    }
    catch (error) {
        throw new Error(error.response?.data || error.message);
    }
}