import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import {Resource} from '../resource/resource';

export interface Source {
    id: string;
    name: string;
    resources: Resource[];
}

@Component
export default class SourceComponent extends Vue {
    sources: Source[] = [];
    mounted() {
        fetch('api/v1/source/getAll')
            .then(response => response.json() as Promise<Source[]>)
            .then(data => {
                this.sources = data;
            });
    }
}
