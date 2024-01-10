import { createApp } from 'vue'
import { createPinia } from 'pinia'
import vuetify from './plugins/vuetify'
import App from './App.vue'
import router from './router'
import './assets/main.css'
import axios from 'axios';

InitializeAppDefaults();

const app = createApp(App)
app.use(createPinia())
app.use(router)
app.use(vuetify)

app.mount('#app')


function InitializeAppDefaults() {
  axios.defaults.baseURL = import.meta.env.VITE_SERVER_APIURL;
}