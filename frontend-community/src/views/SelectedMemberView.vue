<template>
  <SelectedMember />
</template>

<script>
import { defineComponent } from "vue";

// Components
import SelectedMember from '../components/SelectedMember.vue';
// import CommunityMembers from "@/components/CommunityMembers.vue";

export default defineComponent({
  name: 'SelectedMemberView',
  // name: "CommunityMembers",

  components: {
    SelectedMember,
  },
});
</script>
