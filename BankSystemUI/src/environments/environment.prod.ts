export const environment = {
  production: true,
  apiUrl: window.location.hostname === 'localhost'
    ? 'http://localhost:7114/api'
    : 'http://backend:8080/api',
};