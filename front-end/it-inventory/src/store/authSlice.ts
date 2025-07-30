import { createSlice, createAsyncThunk, type PayloadAction } from '@reduxjs/toolkit';
import api from '../api/axios';

interface AuthState {
  token: string | null;
  status: 'idle' | 'loading' | 'authenticated' | 'error';
}

const initialState: AuthState = {
  token: localStorage.getItem('token'),
  status: 'idle',
};

export const login = createAsyncThunk('auth/login', async (credenciais: { email: string; senha: string }) => {
  const response = await api.post('/auth/login', credenciais);
  localStorage.setItem('token', response.data.token);
  return response.data.token;
});

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    logout: (state) => {
      state.token = null;
      state.status = 'idle';
      localStorage.removeItem('token');
    },
  },
  extraReducers: (builder) => {
    builder.addCase(login.pending, (state) => {
      state.status = 'loading';
    });
    builder.addCase(login.fulfilled, (state, action: PayloadAction<string>) => {
      state.token = action.payload;
      state.status = 'authenticated';
    });
    builder.addCase(login.rejected, (state) => {
      state.status = 'error';
    });
  },
});

export const { logout } = authSlice.actions;
export default authSlice.reducer;
