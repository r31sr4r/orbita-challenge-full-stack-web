<template>
    <v-container fluid>
        <v-row justify="center">
            <v-col cols="12" md="4" lg="3"  class="text-center">
                <h6 class="display-1 text-uppercase">Login</h6>
                
                <v-text-field
                    label="Token"
                    v-model="token"
                />

                <v-btn
                    depressed
                    color="primary"
                    dark
                    block
                    class="mb-2"
                    @click="Login"
                    >
                    Login
                </v-btn>

                <v-btn                    
                    text    
                    @click="LoginAsGuest"    
                    color="secondary"

                >
                    Entrar como visitante
                </v-btn>
            </v-col>
        </v-row>  
    </v-container>
</template>

<script>

    export default {
        name: 'LoginPage',
        data() {
            return {
                token: 'AIzaSyCjrSqzMSnLrrucSAPXgLa7iEqum9lD5CA',
            };
        },
        methods: {
            Login() {
                if (this.token) {
                    this.$store.commit('setAuthToken', this.token); 
                    this.$router.push('/student');

                } else {
                    this.$store.commit('showErrorMessage', 'Você deve informar um token!');                                            
                }
                
            },
            LoginAsGuest() {
                this.$store.commit('setLogged', true);    
                // TODO                 
                this.$router.push('/student');

            },
        },            
    };
</script>

<style scoped>

</style>