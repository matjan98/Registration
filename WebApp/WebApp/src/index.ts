import Vue from 'vue';
import Login from './Login';

new Vue({
  el: document.querySelector('#components-demo') as Element,
  components: {Login},
  render(h){
    return h('Login')
  }
})