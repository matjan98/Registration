<template>
  <div style="color:white">
    Hello, {{userModel.firstName + " " + userModel.lastName}}
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator";
import { AccountType, ApiClient, RequestStatus, UserModel } from "../generated/generated"
@Component({ components: {} })
export default class Dashboard extends Vue {
  apiClient = new ApiClient();
  userModel: UserModel = new UserModel();
  created(){
    this.apiClient.whoami().then(x => {
      debugger;
      if(x.status == RequestStatus.Success){
        this.userModel = x.data as UserModel;
        localStorage.setItem("FirstName", this.userModel.firstName as string)
        localStorage.setItem("LastName", this.userModel.lastName as string)
        localStorage.setItem("ID", this.userModel.id.toString())
        localStorage.setItem("AccountType", this.getAccountTypeString(this.userModel.accountType))
      }
    })
  }
  getAccountTypeString(accountType: AccountType): string {
    switch(accountType){
      case AccountType.Patient:
        return "Patient";
      case AccountType.Doctor:
        return "Doctor";
      case AccountType.Admin:
        return "Admin";
    }
  }
}
</script>
