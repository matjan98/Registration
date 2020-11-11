<template>
  <div>
     <q-table
      title="Treats"
      :data="data"
      :columns="columns"
      row-key="name"
      dark
      color="amber"
    ></q-table>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator";
import { ApiClient, RequestStatus } from "../generated/generated"
@Component({ components: {} })
export default class DoctorsList extends Vue {
  apiClient = new ApiClient();
  columns = [
        { name: 'desc', required: true, label: 'Dessert (100g serving)', align: 'left', field: row => row.name, format: val => `${val}`, sortable: true },
        { name: 'calories', align: 'center', label: 'Calories', field: 'calories', sortable: true },
        { name: 'fat', label: 'Fat (g)', field: 'fat', sortable: true },
        { name: 'carbs', label: 'Carbs (g)', field: 'carbs' },
        { name: 'protein', label: 'Protein (g)', field: 'protein' },
        { name: 'sodium', label: 'Sodium (mg)', field: 'sodium' },
        { name: 'calcium', label: 'Calcium (%)', field: 'calcium', sortable: true, sort: (a, b) => parseInt(a, 10) - parseInt(b, 10) },
        { name: 'iron', label: 'Iron (%)', field: 'iron', sortable: true, sort: (a, b) => parseInt(a, 10) - parseInt(b, 10) }
      ];
  data = [];

  created(){
    this.apiClient.listDoctors().then(x => {
      if(x.status == RequestStatus.Success){
        this.data = x.data;
      }
      else{
        this.$q.notify({
          message: x.data,
          color: 'primary'
        })
      }
    });
  }
}

</script>
