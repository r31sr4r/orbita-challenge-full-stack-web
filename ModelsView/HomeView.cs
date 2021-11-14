namespace orbita_challenge_full_stack_web;

public record HomeView
{
    public string Information => "API - A Mais Educação - Gestão de alunos";

    public List<dynamic> Endpoints => new List<dynamic>() {
        new { 
            Item = new { Documentacacao = "/swagger" }
        },
        new { 
            Item = new {Path = "/student" }
        }
    };

}
