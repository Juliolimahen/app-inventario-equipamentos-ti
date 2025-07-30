import { configureStore } from '@reduxjs/toolkit';
import authReducer from './authSlice';
import produtoReducer from './produtoSlice';

export const store = configureStore({
  reducer: {
    auth: authReducer,
    produto: produtoReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
