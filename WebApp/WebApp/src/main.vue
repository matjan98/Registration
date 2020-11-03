<template>
  <div>
     {{test}}
  </div>
</template>

<script lang="ts"> 
import Vue from 'vue'
import { Component, Prop } from "vue-property-decorator";
@Component({ components: { }})
export default class Main extends Vue{
  test = false;
}
</script>