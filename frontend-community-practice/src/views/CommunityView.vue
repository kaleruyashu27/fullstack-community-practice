<template>
  <CommunityMembers />
</template>

<script>
import { defineComponent } from 'vue';

// Components
import CommunityMembers from '../components/CommunityMembers.vue';

export default defineComponent({
  name: 'CommunityView',

  components: {
    CommunityMembers,
  },
});
</script>
