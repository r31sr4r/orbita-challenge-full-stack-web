<template>
  <v-app>
    <app-header />
    
    <v-main>
      <router-view />
    </v-main>
    
    <feedback />

  </v-app>
</template>

<script>
  // 

import apiConfig from './components/api/apiConfig';
import AppHeader from './components/header/AppHeader.vue';
import Feedback from './components/feedback/Feedback.vue';

export default {
  name: 'App',
  components: { AppHeader, Feedback },
  mixins: [apiConfig],
  created() {
    this.createInterceptors();

    if (window.localStorage.authToken) {
      this.$store.commit('setAuthToken', window.localStorage.authToken);
    } else {
      this.$router.push('/');
    }
  },  
  
};
</script>

