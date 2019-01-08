import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import L from 'leaflet';
import {LPopup, LMap, LTileLayer, LCircleMarker, LTooltip} from 'vue2-leaflet';
// import 'leaflet/dist/leaflet.css'

Vue.component('l-map', LMap);
Vue.component('l-tile-layer', LTileLayer);
Vue.component('l-marker', LCircleMarker);

Vue.component('l-popup', LPopup);
Vue.component('l-tooltip', LTooltip);

L.Icon.Default.imagePath = '.';
L.Icon.Default.mergeOptions({
    iconRetinaUrl: require('leaflet/dist/images/marker-icon-2x.png'),
    iconUrl: require('leaflet/dist/images/marker-icon.png'),
    shadowUrl: require('leaflet/dist/images/marker-shadow.png'),
});

Vue.use(VueRouter);

const routes = [
    { path: '/', component: require('./components/home/home.vue.html').default },
    { path: '/counter', component: require('./components/counter/counter.vue.html').default },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html').default },
    { path: '/resources', component: require('./components/resource/resource.vue.html').default},
    { path: '/sources', component: require('./components/source/source.vue.html').default},
    { path: '/sources/:sourceId/createAssay', component: require('./components/assay/createAssaySource.vue.html').default}
];


new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html').default),
    
});

