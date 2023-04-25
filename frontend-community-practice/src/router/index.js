import { createRouter, createWebHistory } from 'vue-router'
import CommunityView from '../views/CommunityView.vue'
import SelectedMemberView from '../views/SelectedMemberView.vue'


const routes = [
  {
    path: '/',
    name: 'Community',
    alias: '/community',
    component: CommunityView
  },
  {
    path: '/community/:id ',
    name: 'SelectedMember',
    component: SelectedMemberView,
    props: true
  },
  
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
