<template>
  <v-container>
    <v-data-table :headers="headers" :items="CommunityMembers" :items-per-page="5" >
      <template v-slot:item = "{ item }">
        <tr>
          <td>{{ item.columns.id }}</td>
          <td>{{ item.columns.fullName }}</td>
          <td>{{ item.columns.email }}</td>
          <td>{{ item.columns.phone }}</td>
          <td>{{ item.columns.address }}</td>
          <td>
            <v-btn @click="onNewPageButtonClick(item.columns.id)">Display This Member</v-btn>
          </td>
        </tr>
      </template>
    </v-data-table>
  </v-container>
</template>

<script>
import $https from "../http-common.js"
export default {
  name: "CommunityMembers",

  data: () => ({
    headers: [
      {title: "ID", align: "start", sortable: "false", key: "id"},
      {title: "FullName", sortable: "false", key: "fullName"},
      {title: "Email", sortable: "false", key: "email"},
      {title: "Phone", sortable: "false", key: "phone"},
      {title: "Address", sortable: "false", key: "address"},
      {title: "Button", sortable: "false", key: "newPageButton"}
    ],
    CommunityMembers: []
  }),

  methods: {
    async getCommunityMembers() {
      await $https
      .get("/Community")
      .then((response) => {
        this.CommunityMembers = response.data;
      }) 
      .catch((e) => {
        console.log(e);
      });
    },
    onNewPageButtonClick(id){
      console.log(id);
      this.$router.push({name:"SelectedMember", params:{id}});
    },
  },
  mounted(){
    this.getCommunityMembers();
  }
};
</script>
