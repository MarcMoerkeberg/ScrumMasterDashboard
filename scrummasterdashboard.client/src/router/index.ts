import { createRouter, createWebHistory } from 'vue-router'
import LandingPage from '../views/LandingPage.vue'
import routes from './routes'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: routes.LandingPage.Route,
      name: routes.LandingPage.Title,
      component: LandingPage
    },
  ]
})

export default router
