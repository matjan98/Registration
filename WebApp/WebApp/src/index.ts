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

Vue.use(Quasar, {
  config: {},
  plugins: {
  }
 })

Vue.use(VueRouter)

import Login from './login';
import Register from './register';

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