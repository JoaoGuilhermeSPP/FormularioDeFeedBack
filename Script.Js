async function envio() {

    const estrelaSelecionada = document.querySelector("input[name='estrelas']:checked");
    
    if (!estrelaSelecionada) {
        alert("Por favor, selecione uma avaliação com estrelas!");
        return;
    }

    const dados = {
        nome: document.getElementById('nome').value,
        email: document.getElementById('email').value,
        telefone: document.getElementById("telefone").value,
        estrelas: parseInt(estrelaSelecionada.value),
        feedback: document.getElementById("feedback").value
    };

    console.log("Dados sendo enviados:", dados); // Para debug

    try {
        const resposta = await fetch('http://localhost:5020/api/Envio/enviar', {
            method: 'POST',
            headers: { 
                "Content-Type": "application/json" 
            },
            body: JSON.stringify(dados)
        });

        const resultado = await resposta.json();
        
        if (resposta.ok) {
            alert("Enviado! Obrigado pelo feedback ❤️");
            // Limpa o formulário
            document.getElementById('satisfactionForm').reset();
        } else {
            alert(`Erro: ${resultado.mensagem}`);
        }

    } catch (error) {
        alert("Falha na conexão com o servidor.");
        console.error("Erro detalhado:", error);
    }
}