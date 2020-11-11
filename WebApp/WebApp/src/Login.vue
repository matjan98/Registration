<template>
  <div style="margin-top: 30px;">
    <q-card class="login-card" dark>
      <q-card-section dark>
        <q-form class="q-gutter-md">
          <q-input
            ref="login"
            dark
            filled
            v-model="login"
            label="Login"
            class="fix-chrome-input"
          ></q-input>

          <q-input
            ref="password"
            dark
            filled
            type="password"
            v-model="password"
            label="Password"
            class="fix-chrome-input"
          ></q-input>

          <router-link to="/register">Reqister</router-link>

          <div>
            <q-btn label="Login" color="primary" @click="Login"></q-btn>
          </div>
        </q-form>
      </q-card-section>
    </q-card>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator";
import { ApiClient, RequestStatus } from "./generated/generated"
@Component({ components: {} })
export default class Login extends Vue {
  apiClient = new ApiClient();
  login = "";
  password = "";

  Login(){
    this.apiClient.logIn(this.login, this.password).then(x => {
      if(x.status == RequestStatus.Success){
        this.$q.notify({
          message: "Logged successfuly",
          color: 'primary'
        })
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
	}

}
</script>


<style scoped>
.login-card{
  width: 300px;
  margin-top: 50px;
  margin: auto;
}

input:-webkit-autofill {
	-webkit-text-fill-color: #fff !important;
	-webkit-box-shadow: 0 0 0 1rem var(--page-background-color) inset !important;
	background-clip: text !important;
	caret-color: #fff !important;
}


</style>