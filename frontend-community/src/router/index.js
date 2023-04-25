import { createRouter, createWebHashHistory } from 'vue-router'
// import HomeView from '../views/HomeView.vue'
import CommunityView from '../views/CommunityView.vue'
import SelectedMemberView from '../views/SelectedMemberView.vue'

const routes = [
  {
    path: '/',
    alias: '/community',
    name: 'Community',
    component: CommunityView
  },
  {
    path: '/community/:id',
    name: 'SelectedMember',
    component: SelectedMemberView,
    props: true
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
