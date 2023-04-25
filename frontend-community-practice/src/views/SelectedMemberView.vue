<template>
    <SelectedMember />
  </template>
  
  <script>
  import { defineComponent } from 'vue';
  
  // Components
  import SelectedMember from '../components/SelectedMember.vue';
  
  export default defineComponent({
    name: 'SelectedMemberView',
  
    components: {
        SelectedMember,
    },
  });
  </script>
  