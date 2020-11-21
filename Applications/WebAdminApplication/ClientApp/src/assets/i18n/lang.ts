export const LANGUAGE = [
    { key: 'en', value: 'English' },
    { key: 'vi', value: 'Tiếng Việt' }
];

export class Language {
    key: string;
    value: string;
    constructor(key?: string, value?: string) {
        this.key = key;
        this.value = value;
    }
}
