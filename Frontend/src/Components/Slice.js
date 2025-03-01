import { createSlice } from "@reduxjs/toolkit";

export const loggedSlice = createSlice({
    name: 'logged',
    initialState: {
        loggedIn : false
    },
    reducers: {
        login: (state) => {console.log("in dispatch");return {loggedIn: true}},
        logout: (state) => {
            console.log("in logout dispatch")
            return {loggedIn: false}
        }
    }
})

 export const { login, logout } = loggedSlice.actions;
export default loggedSlice.reducer;