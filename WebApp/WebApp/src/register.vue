<template>
  <div style="margin-top: 30px;">
    <q-card class="login-card" dark>
      <q-card-section dark>
        <q-form class="q-gutter-md">
          <q-input
            dark
            filled
            v-model="login"
            label="Login"
          ></q-input>

          <q-input
            dark
            filled
            type="password"
            v-model="password"
            label="Password"
          ></q-input>

          <q-input
            dark
            filled
            type="password"
            v-model="password"
            label="Repeat password"
          ></q-input>

          <div>
            <q-btn label="Reqister" color="primary"></q-btn>
          </div>
        </q-form>
      </q-card-section>
    </q-card>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator";
@Component({ components: {} })
export default class Register extends Vue {
  login = "";
  password = "";
}
</script>


<style scoped>
.login-card{
  width: 300px;
  margin-top: 50px;
  margin: auto;
}
</style>