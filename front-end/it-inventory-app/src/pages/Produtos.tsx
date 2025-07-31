import { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from '../store/hooks';
import { fetchProdutos } from '../store/produtoSlice';

export default function Produtos() {
  const dispatch = useAppDispatch();
  const produtos = useAppSelector(state => state.produto.lista);

  useEffect(() => {
    dispatch(fetchProdutos());
  }, [dispatch]);

  return (
    <div>
      <h1>Produtos</h1>
      <ul>
        {produtos.map(prod => (
          <li key={prod.id}>{prod.nome} - R$ {prod.preco.toFixed(2)}</li>
        ))}
      </ul>
    </div>
  );
}
