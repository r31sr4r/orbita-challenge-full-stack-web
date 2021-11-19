<template>
  <v-data-table
    :headers="headers"
    :items="studentList"
    sort-by="name"
    class="elevation-1"
  >
    <template v-slot:top>
      <v-toolbar
        flat
      >
        <v-toolbar-title>Gestão de Alunos</v-toolbar-title>
        <v-divider
          class="mx-4"
          inset
          vertical
        ></v-divider>
        <v-spacer></v-spacer>
        <v-dialog
          v-model="dialog"
          max-width="500px"
        >
          <template v-slot:activator="{ on, attrs }">
            <v-btn
              color="primary"
              dark
              class="mb-2"
              v-bind="attrs"
              v-on="on"
            >
              Novo Aluno
            </v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="text-h5">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>              
              <v-container>
                <v-form ref="form" lazy-validation>
                  <v-row>
                    <v-col
                      cols="12"                    
                      md="8"
                    >
                      <v-text-field
                        v-model="editedItem.name"
                        label="Nome"
                        :rules="nameRules"
                        required
                      ></v-text-field>
                    </v-col>
                    <v-col
                      cols="12"
                      md="4"
                    >
                      <v-text-field
                        v-model="editedItem.cpf"
                        label="CPF"
                        :rules="cpfRules"
                        required
                        v-mask="'###.###.###-##'"
                      ></v-text-field>
                    </v-col>
                    <v-col
                      cols="12"
                      md="8"
                    >
                      <v-text-field
                        v-model="editedItem.email"
                        label="Email"
                        :rules="emailRules"
                        required
                      ></v-text-field>
                    </v-col>
                    <v-col
                      cols="12"
                      md="4"
                    >
                      <v-text-field
                        v-model="editedItem.id"
                        label="RA"
                        
                        disabled
                      ></v-text-field>
                    </v-col>
                  </v-row>
                </v-form>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="blue darken-1"
                text
                @click="close"
              >
                Cancelar
              </v-btn>
              <v-btn
                color="blue darken-1"
                text
                @click="save"
              >
                Salvar
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
        <v-dialog v-model="dialogDelete" max-width="500px">
          <v-card>
            <v-card-title class="text-h6">Tem certeza que deseja excluir este aluno?</v-card-title>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" text @click="closeDelete">Cancel</v-btn>
              <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:item.actions="{ item }">
      <v-icon
        small
        class="mr-2"
        @click="editItem(item)"
      >
        mdi-pencil
      </v-icon>
      <v-icon
        small
        @click="deleteItem(item)"
      >
        mdi-delete
      </v-icon>
    </template>
    <template v-slot:no-data>
        <p>Não existem alunos cadastrados</p>
        <!--
      <v-btn
        color="primary"
        @click="initialize"
      >
        Reset
      </v-btn>
      -->
    </template>
  </v-data-table>
</template>

<script>
    import api from '../api/api';
    
    export default {
        name: 'StudentListPage',  
        mixins: [api],
        data: () => ({    
          dialog: false,
          dialogDelete: false,
          headers: [
              {
              text: 'Nome',
              align: 'start',
              sortable: false,
              value: 'name',
              },
              { text: 'CPF', value: 'cpf' },
              { text: 'Email', value: 'email' },
              { text: 'RA', value: 'id' },
              { text: 'Ações', value: 'actions', sortable: false },
          ],
          desserts: [],
          editedIndex: -1,
          editedItem: {
              name: '',
              id: '00000',
              cpf: '',
              email: '',
          },
          defaultItem: {
              name: '',
              id: '00000',
              cpf: '',
              email: '',
          },
          nameRules: [
            v => !!v || 'Nome é obrigatório',
          ],
          emailRules: [
              v => !!v || 'Email é obrigatório',
              v => /.+@.+/.test(v) || 'Digite um e-mail válido.',
              
          ],        
          cpfRules: [
              v => !!v || 'CPF é obrigatório',
          ],          
          studentList: [],
        }),

        computed: {
        formTitle () {
            return this.editedIndex === -1 ? 'Novo Aluno' : 'Edição de Aluno'
        },
        },

        watch: {
        dialog (val) {
            val || this.close()
        },
        dialogDelete (val) {
            val || this.closeDelete()
        },
        },

        created () {
            this.get('/student').then((response) => {
                this.studentList = response.data.results;                
            });
        },

        methods: {
            
        editItem (item) {
            this.editedIndex = this.studentList.indexOf(item)
            this.editedItem = Object.assign({}, item)
            this.dialog = true
         
        },

        deleteItem (item) {
            this.editedIndex = this.studentList.indexOf(item)
            this.editedItem = Object.assign({}, item)
            this.dialogDelete = true
        },

        deleteItemConfirm () {
            this.delete('/student/' + this.editedItem.id).then((response) => {
              console.log(response.data.id);
              this.$store.commit('showSuccessMessage', `Aluno ${this.editedItem.name} excluído com sucesso!`);

            });
            this.studentList.splice(this.editedIndex, 1)
            this.closeDelete()

        },

        close () {
            this.dialog = false
            this.$nextTick(() => {
            this.editedItem = Object.assign({}, this.defaultItem)
            this.editedIndex = -1
            })
        },

        closeDelete () {
            this.dialogDelete = false
            this.$nextTick(() => {
            this.editedItem = Object.assign({}, this.defaultItem)
            this.editedIndex = -1
            })
        },

        save () {
            this.$refs.form.validate();
            //Se o aluno está sendo editado, então o sistema faz a chamada do método PUT para atualizar
            if (this.editedItem.name && this.editedItem.email && this.editedItem.email) {
              if (this.editedIndex > -1) {                
                  Object.assign(this.studentList[this.editedIndex], this.editedItem)
                    this.put('/student/' + this.editedItem.id, this.editedItem).then((response) => {
                    console.log(response.data.id);
                    this.$store.commit('showSuccessMessage', `Aluno ${response.data.name} atualizado com sucesso!`);
                  });      
              } else {
                  //Se o aluno é novo, então o sistema faz a chamada do método POST para Cadastrar
                    this.post('/student', this.editedItem).then((response) => {
                    this.editedItem.id = response.data.id;
                    this.$store.commit('showSuccessMessage', `Aluno cadastrado com sucesso!`);
                  });     
                    this.studentList.push(this.editedItem)
                    this.get('/student').then((response) => {
                      this.studentList = response.data.results;   
                    });
              }
              this.close()
            }
        },
        },
    };
</script>

<style scoped>

</style>