use data_probleme;

-- Quelques requêtes spéciales

# Cumul des commandes

select nom_particulier as 'nom',count(*) as 'nombre de commandes' from client_particulier join commande using(id_particulier) group by id_particulier;

select nom_compagnie_entrepriseas 'nom',count(*) as 'nombre de commandes' from Client_entreprise join commande using(nom_compagnie_entreprise) group by nom_compagnie_entreprise;

select nom_compagnie_entreprise as 'nom', count(*) as 'nombre de commandes' from Client_entreprise join commande using(nom_compagnie_entreprise) where nom_compagnie_entreprise='Easy Rider';

select nom_particulier as 'nom', count(*) as 'nombre de commandes' from client_particulier join commande using(id_particulier) where nom_particulier='Detair';

# Nombre de pièces fournis par utilisateur

select count(*) as 'Nombres de pièces',nom_fournisseur as fournisseur from piece group by nom_fournisseur;

#Produits en stock <= 2

select * 
from (
select num_produit_piece as num_produit,count(*) as nb_stock_piece from Piece group by num_produit having nb_stock_piece<=2
union all
select num_modele_bicyclette,count(*) as nb_stock_bicyclette from Bicyclette group by num_modele_bicyclette having nb_stock_bicyclette<=2
) as nb_stock;

# Prix

select concat(nom_particulier,' ',prenom_particulier) as client,sum(number) as total
from
(
    select num_commande,sum(prix_unitaire_bicyclette) as number,id_particulier
    from commande join bicyclette using(num_commande) where id_particulier is not null group by num_commande
    union all
    select num_commande,sum(prix_unitaire_piece) as number,id_particulier
    from commande join piece using(num_commande) where id_particulier is not null group by num_commande
) t
join client_particulier using(id_particulier)
group by id_particulier

union


select nom_compagnie_entreprise as client ,sum(number) as total
from
(
    select num_commande,sum(prix_unitaire_bicyclette) as number,nom_compagnie_entreprise
    from commande join bicyclette using(num_commande) where nom_compagnie_entreprise is not null group by num_commande
    union all
    select num_commande,sum(prix_unitaire_piece) as number, nom_compagnie_entreprise
    from commande join piece using(num_commande) where nom_compagnie_entreprise is not null group by num_commande
) t
group by nom_compagnie_entreprise;


select num_commande,sum(number) as prix
from
(
    select num_commande,sum(prix_unitaire_bicyclette) as number
    from commande join bicyclette using(num_commande) group by num_commande
    union all
    select num_commande,sum(prix_unitaire_piece) as number
    from commande join piece using(num_commande) group by num_commande
) t
where num_commande = 5;

# Somme du nombre total des clients

Select 
sum(b) as Nombre_total_de_clients
from (
select count(*) as b from Client_entreprise 
union all 
select count(*) from Client_particulier 
) as a;

