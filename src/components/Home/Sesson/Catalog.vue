<script setup lang="ts">
import { getCatalogs } from '@/services';
import { DotLottieVue } from '@lottiefiles/dotlottie-vue';
import { onMounted, ref } from 'vue';

const catalogs = ref<any>([])

const showcatalog = async () => {
    try {
        const res = await getCatalogs()
        const resdata = res.data
        catalogs.value = resdata.map((catalog: any) => ({
            id: catalog.id,
            name: catalog.name,
            desVI: catalog.desVI
        }))
    } catch (error: any) {
        console.log("Lỗi lấy catalog" + error)
    }
}
onMounted(() => {
    showcatalog()
})
</script>

<template>
    <div class="container my-5 position-relative">
        <DotLottieVue class="mascot-img" autoplay loop
            src="https://lottie.host/c737534b-c300-4560-aed5-18ba418c75f8/naORkESB7T.lottie" />
        <div class="program-box">
            <div class="program-title">
                Những chương trình học<br>
                có thể phù hợp với bạn
            </div>
            <div class="program-buttons">
                <div class="d-flex flex-wrap gap-3">
                    <RouterLink v-for="(catalog, index) in catalogs" :key="catalog.id"
                        :to="{ name: 'DetailCatalog', params: { id: catalog.id } }">
                        {{ catalog.name }} →
                    </RouterLink>
                </div>

            </div>
        </div>
    </div>

</template>
<style scoped>
.program-box {
    background: linear-gradient(90deg, #007bff, #001f5f);
    color: white;
    border-radius: 30px;
    padding: 30px;
    display: flex;
    align-items: center;
    justify-content: space-between;
    flex-wrap: wrap;
}

.program-title {
    font-size: 1.8rem;
    font-weight: 600;
    max-width: 50%;
}

.program-buttons {
    display: flex;
    flex-wrap: wrap;
    gap: 15px;
    max-width: 50%;
    justify-content: flex-end;
}

.program-buttons a {
    border: 2px solid white;
    border-radius: 25px;
    padding: 10px 20px;
    color: white;
    font-weight: bold;
    text-decoration: none;
    transition: background 0.3s, color 0.3s;
}

.program-buttons a:hover {
    background-color: white;
    color: #001f5f;
}

.mascot-img {
    position: absolute;
    top: 12%;
    left: 35%;
    width: 120px;
    height: 120px;
    z-index: 1;
}
</style>