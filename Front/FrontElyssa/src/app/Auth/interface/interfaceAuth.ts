export interface Login {
    password: string;
    user: string;
}
export interface ResponseLogin {
    code: number;
    description: string;
    identity: number;
}