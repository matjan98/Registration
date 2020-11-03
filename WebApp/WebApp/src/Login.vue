<template>
  <div>
    Login page
    <q-checkbox v-model="test">
    </q-checkbox>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
import { Component, Prop } from "vue-property-decorator";
@Component({ components: { }})
export default class Login extends Vue{
  test = false;
}

</script>
