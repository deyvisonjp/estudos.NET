import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class FetchProduto extends Component {
    static displayName = "Produtos";

    constructor() {
        super();
        this.state = { produtos: [], loading: true }
    }
    componentDidMount() {
        this.populaProdutoData();
    }

    static handleEdit(id) {
        window.location.href = "/produto/edit" + id;
    }

    static handleDelete(id) {
        if (!window.confirm("Você deseja deletar o produto " + id + " ?")) {
            return;
        } else {
            fetch('api/produtos/' + id, { method: 'delete' })
                .then(json => {
                    window.location.href = "fetch-produto";
                    alert('Deletado com Sucesso!');
                })
        }
    }

    static renderProdutosTabela(produtos) {
        return (
            <table className='table table-striped' aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Código</th>
                        <th>Descrição</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        produtos.map(prod =>
                            <tr key={prod.id}>
                                <td> {prod.id} </td>
                                <td> {prod.descricao} </td>

                                <td>
                                    <button className="btn btn-success" onClick={(id) => this.handleEdit(prod.id)}> Editar </button> &nbsp;
                                    <button className="btn btn-danger" onClick={(id) => this.handleDelete(prod.id)}> Excluir </button>
                                </td>
                            </tr>
                        )
                    }
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em> Carregando . . . </em></p>
            : FetchProduto.renderProdutosTabela(this.state.produtos);
        return (
            <div>
                <h1 id="tableLabel">Produtos</h1>
                <p>Tela de listagem de Produtos</p>
                <p>
                    <Link to="/add-produto">Cadastrar Produto</Link>
                </p>

                {contents}

            </div>
        );
    }

    async populaProdutoData() {
        const response = await fetch("api/Produtos");
        const data = await response.json();
        this.setState({ produtos: data, loading: false })
    }
}




    // https://youtu.be/sfPtSV1AwqY