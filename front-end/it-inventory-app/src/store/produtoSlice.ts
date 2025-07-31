import { createSlice, createAsyncThunk, type PayloadAction } from '@reduxjs/toolkit';
import api from '../api/axios';

interface Produto {
  id: number;
  nome: string;
  preco: number;
}

interface ProdutoState {
  lista: Produto[];
  status: 'idle' | 'loading' | 'loaded' | 'error';
}

const initialState: ProdutoState = {
  lista: [],
  status: 'idle',
};

export const fetchProdutos = createAsyncThunk('produto/fetch', async () => {
  const response = await api.get('/produtos');
  return response.data;
});

const produtoSlice = createSlice({
  name: 'produto',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(fetchProdutos.pending, (state) => {
      state.status = 'loading';
    });
    builder.addCase(fetchProdutos.fulfilled, (state, action: PayloadAction<Produto[]>) => {
      state.lista = action.payload;
      state.status = 'loaded';
    });
    builder.addCase(fetchProdutos.rejected, (state) => {
      state.status = 'error';
    });
  },
});

export default produtoSlice.reducer;
