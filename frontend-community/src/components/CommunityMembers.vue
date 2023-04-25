<template>
  <v-app>
    <v-data-table :headers="headers" :items="communityMembers">
      <template v-slot:item="{ item }">
        <tr>
          <td>{{ item.columns.id }}</td>
          <td>{{ item.columns.fullName }}</td>
          <td>{{ item.columns.email }}</td>
          <td>{{ item.columns.phone }}</td>
          <td>{{ item.columns.address }}</td>
          <td>
            <v-btn @click="onNewPageButtonClick(item.columns.id)">
              Display this Row in New Page
            </v-btn>
          </td>
        </tr>
      </template>
    </v-data-table>
  </v-app>
</template>

<script>
// import $https from "../http-common";
import axios from 'axios';

export default {
  name: "CommunityMembers",

  data: () => ({
    headers: [
      { title: "Id", align: "start", sortable: false, key: "id" },
      { title: "Full Name", key: "fullName", sortable: true },
      { title: "Email", key: "email", sortable: false },
      { title: "Phone", key: "phone", sortable: false },
      { title: "Address", key: "address", sortable: false },
      { title: "Button Column", key: "newPageButton" },
    ],
    communityMembers: [
      // {
      //   id: 1,
      //   fullName: "Name 1",
      //   email: "name1@email.com",
      //   phone: 11323433,
      //   address: "Address 1",
      // },
    ],
  }),
  methods: {
    async retrieveCommunityMembers() {
      // await $https
      await axios
        .get("https://localhost:7091/api/community")
        .then((response) => {
          this.communityMembers = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
    },

    onNewPageButtonClick(id) {
      // console.log("Id of the selected row: " + id);
      this.$router.push({ name:"SelectedMember", params: { id } });
    }
  },
  mounted() {
    this.retrieveCommunityMembers();
  },
};
</script>
