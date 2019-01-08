var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
export class Source {
    constructor() {
        this.id = "";
        this.name = "";
        this.resources = [];
    }
}
let SourceComponent = class SourceComponent extends Vue {
    constructor() {
        super(...arguments);
        this.sources = [];
    }
    mounted() {
        fetch('api/v1/source/getAll')
            .then(response => response.json())
            .then(data => {
            this.sources = data;
        });
    }
    getGroups(count) {
        let c = 0;
        let result = [];
        let tmp = [];
        for (let s of this.sources) {
            c++;
            tmp.push(s);
            if (c == count) {
                c = 0;
                result.push(tmp);
                tmp = [];
            }
        }
        result.push(tmp);
        return result;
    }
};
SourceComponent = __decorate([
    Component
], SourceComponent);
export default SourceComponent;
//# sourceMappingURL=source.js.map