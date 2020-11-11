<template>
  <div style="margin-top: 30px;">
    <q-card class="login-card" dark>
      <q-card-section dark>
        <q-form class="q-gutter-md">
          <q-input
            ref="firstName"
            dark
            filled
            v-model="firstName"
            label="First name"
          ></q-input>

          <q-input
            ref="lastName"
            dark
            filled
            v-model="lastName"
            label="Last name"
          ></q-input>

          <q-input
            ref="login"
            dark
            filled
            v-model="login"
            label="Login"
          ></q-input>

          <q-input
            ref="password"
            dark
            filled
            type="password"
            v-model="password"
            label="Password"
          ></q-input>

          <q-input
            ref="passwordRepeat"
            dark
            filled
            type="password"
            v-model="passwordRepeat"
            label="Repeat password"
          ></q-input>

          <div>
            <q-btn label="Reqister" color="primary" @click="Register"></q-btn>
          </div>
        </q-form>
      </q-card-section>
    </q-card>
  </div>
</template>

<script lang="ts">
import { ApiClient, RequestStatus } from "./generated/generated";
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator";
@Component({ components: {} })
export default class Register extends Vue {
  apiClient = new ApiClient();
  firstName = "";
  lastName = "";
  login = "";
  password = "";
  passwordRepeat = "";

  Register(){
    this.apiClient.register(this.firstName, this.lastName, this.login, this.password, undefined).then(x => {
      if(x.status == RequestStatus.Success){
        localStorage.setItem("Token", x.data)
      }
      else{
        this.$q.notify({
          message: x.data,
          color: 'primary'
        })
      }
    });
  }

  fixChromesInputAutofillStyle(input: HTMLElement) {
		const style = `-webkit-text-fill-color: #fff !important;
						-webkit-background-clip: text !important;
						caret-color: #fff !important;`;

		input.style.cssText = style;
	}

	mounted() {
		this.fixChromesInputAutofillStyle((this.$refs.login as any).$refs.input);
		this.fixChromesInputAutofillStyle((this.$refs.password as any).$refs.input);
		this.fixChromesInputAutofillStyle((this.$refs.passwordRepeat as any).$refs.input);
	}
}
</script>


<style scoped>
.login-card{
  width: 300px;
  margin-top: 50px;
  margin: auto;
}
</style>