<template>    
  <div>
    <v-toolbar
      dark
      prominent
      src="https://cdn.vuetifyjs.com/images/backgrounds/vbanner.jpg"
    >
      <v-app-bar-nav-icon  
        @click.stop="drawer = !drawer"
        v-if="$store.state.logged"
      >
      </v-app-bar-nav-icon>


      <v-spacer></v-spacer>

      <v-toolbar-title>Grupo A - Módulo Acadêmico</v-toolbar-title>

      <v-btn icon>
        <v-icon 
            @click="logout"
            v-if="$store.state.logged"
        >mdi-export
        </v-icon>
      </v-btn>
    </v-toolbar>

        <v-navigation-drawer
      v-model="drawer"
      absolute
      bottom
      temporary
    >
      <v-list
        nav
        dense
      >
        <v-list-item-group
          v-model="group"
          active-class="deep-purple--text text--accent-4"
          v-if="$store.state.logged"
        >

          <v-list-item>
            <v-list-item-title @click="goToStudentList">Alunos</v-list-item-title>
          </v-list-item>

          <v-list-item>
            <v-list-item-title @click="logout">Sair</v-list-item-title>
          </v-list-item>

        </v-list-item-group>
      </v-list>
    </v-navigation-drawer>

  </div>

</template>

<script>
    export default {
        data: () => ({
            drawer: false,
            group: null,
        }),

        watch: {
            group () {
                this.drawer = false
            },
        },
        name: 'AppHeader',
        methods: {
            goToStudentList() {
                this.$router.push('/student');
            },          
            logout() {
                this.$store.commit('setAuthToken', '');
                this.$router.push('/');
            },                     
        },
    };
</script>

<style scoped>

</style>