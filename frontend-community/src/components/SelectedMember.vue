<template>
  <v-container>
    <div>
      <h1>Member Details</h1>

      <div>
        <p><strong>Full Name:</strong></p>
        <div class="d-flex align-center">
          <v-text-field
            v-model="communityMember.fullName"
            dense
            filled
            class="mr-2"
            :maxlength="5"
          />
          <v-btn @click="updateName" color="teal" dark> Update Name </v-btn>
        </div>
      </div>

      <div><strong>Email:</strong> {{ communityMember.email }}</div>
      <div><strong>Phone:</strong> {{ communityMember.phone }}</div>
      <div><strong>Address:</strong> {{ communityMember.address }}</div>
    </div>
    <router-link :to="{ name: 'Community' }">
      <v-btn color="primary">Back to Community</v-btn>
    </router-link>
  </v-container>
</template>

<script>
import $https from "../http-common.js";
export default {
  name: "CommunityMembers",
  props: ["id"],

  data: () => ({
    communityMember: {},
  }),

  methods: {
    async getCommunityMember() {
      await $https
        .get(`/Community/${this.id}`)
        .then((response) => {
          this.communityMember = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
    },
    async updateName() {
      await $https
        .put(`/Community/${this.id}`, {
          fullName: this.communityMember.fullName,
        })
        .then(() => {
          console.log("Name Updated Successfully");
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
  mounted() {
    this.getCommunityMember();
  },
};
</script>
