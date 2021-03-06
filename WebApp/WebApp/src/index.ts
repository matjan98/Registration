import Vue from 'vue';
import VueRouter from 'vue-router';
import 'quasar/dist/quasar.css'
import 'quasar/dist/quasar.ie.polyfills'
import '@quasar/extras/roboto-font/roboto-font.css'
import '@quasar/extras/material-icons/material-icons.css'
import '@quasar/extras/material-icons-outlined/material-icons-outlined.css'
import '@quasar/extras/material-icons-round/material-icons-round.css'
import '@quasar/extras/material-icons-sharp/material-icons-sharp.css'
import '@quasar/extras/fontawesome-v5/fontawesome-v5.css'
import '@quasar/extras/ionicons-v4/ionicons-v4.css'
import '@quasar/extras/mdi-v4/mdi-v4.css'
import '@quasar/extras/eva-icons/eva-icons.css'
import Quasar from 'quasar'
import { Notify } from 'quasar'
Vue.use(Quasar, {
  config: {},
  plugins: [Notify]
 })

Vue.use(VueRouter)

import Login from './pages/login';
import Register from './pages/register';
import Dashboard from './pages/dashboard';
import DoctorsList from './pages/doctorsList';
import MyVisits from './pages/myVisits';
import AppointmentsList from './pages/appointmentsList';

const router = new VueRouter({
  mode: 'history',
  base: __dirname,
  routes: [
    {
      path: '/',
      name: "login",
      component: Login,
    },
    {
      path: '/register',
      name: "register",
      component: Register,
    },
    {
      path: '/dashboard',
      name: "dashboard",
      component: Dashboard,
    },
    {
      path: '/doctorsList',
      name: "doctorsList",
      component: DoctorsList,
    },
    {
      path: '/appointmentsList',
      name: "appointmentsList",
      component: AppointmentsList,
    },
    {
      path: '/myVisits',
      name: "myVisits",
      component: MyVisits,
    },
  ]
});

router.beforeEach((to: any, from: any, next: any) => {
	next();
});


new Vue({
  router,
  template: ` <div>
  <router-view :key="$route.fullPath"></router-view>
</div>`
}).$mount('#components-demo')