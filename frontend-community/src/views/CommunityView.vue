<template>
  <CommunityMembers />
</template>

<script>
import { defineComponent } from "vue";

// Components
import CommunityMembers from '../components/CommunityMembers.vue';
// import CommunityMembers from "@/components/CommunityMembers.vue";

export default defineComponent({
  name: 'CommunityView',
  // name: "CommunityMembers",

  components: {
    CommunityMembers,
    // CommunityMembers,
  },
});
</script>
