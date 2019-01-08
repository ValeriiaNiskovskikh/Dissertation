import Vue from 'vue';
import { Component } from 'vue-property-decorator';

export class Resource {
    id: string = "";
    name: string = "";
}

@Component
export default class ResourceComponent extends Vue {
    resources: Resource[] = [];
    mounted() {
        fetch('api/v1/resource/getAll')
            .then(response => response.json() as Promise<Resource[]>)
            .then(data => {
                this.resources = data;
            });
    }
}
