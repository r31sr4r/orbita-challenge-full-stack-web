import Vue from "vue";
import Router from "vue-router";

import LoginPage from './components/login/LoginPage.vue';
import StudentListPage from './components/student/StudentListPage.vue';

Vue.use(Router);

const routes = [
    { path: '/', name: 'login', component: LoginPage },
    { path: '/student', name: 'studentList', component: StudentListPage },

];

export default new Router({
    routes,
});