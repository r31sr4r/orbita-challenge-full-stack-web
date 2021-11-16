<template>
    <div>
        <div v-if="condition">
            <v-progress-linear
            indeterminate
            color="cyan"
            ></v-progress-linear>
        </div>
        <div v-if="!condition">
            <slot />
        </div>    
    </div>
</template>

<script>
export default {
    name: 'Loading',
    props: {
        condition: { type: Boolean, required: true },
    },
}
</script>

<style scoped>

</style>