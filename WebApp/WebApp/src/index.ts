import Vue from 'vue';
import Login from './Login';
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const router = new VueRouter({
  mode: "history",
  routes: [
		{
			path: "/login",
			component: Login,
    }
  ]
})

router.beforeEach((to: any, from: any, next: any) => {
  next({
    path: "/login",
    query: { redirect: to.path }
  });
});

new Vue({
  router,
  el: document.querySelector('#components-demo') as Element,
  components: {Login},
  render(h){
    return h('Login')
  }
})