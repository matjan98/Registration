<template>
  <div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator";
import { ApiClient, RequestStatus } from "../generated/generated"
@Component({ components: {} })
export default class MyVisits extends Vue {
  apiClient = new ApiClient();

}
</script>
