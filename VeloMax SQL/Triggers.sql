use data_probleme;

-- Trigger Commande
 
# trigger delete commande

delimiter |
create trigger Delete_num_commande_des_pieces_et_bicyclette
before delete on Commande
for each row
begin
	update Piece as p set p.num_commande=null where old.num_commande=p.num_commande;
    update Bicyclette as b set b.num_commande=null where old.num_commande=b.num_commande;
end |


-- Trigger Client entreprise

#Trigger Delete Client entreprise de la commande

delimiter |
create trigger Delete_client_entreprise
before delete on Client_entreprise
for each row
begin

	delete from Commande where Commande.nom_compagnie_entreprise = old.nom_compagnie_entreprise;
end |


-- Trigger Client particulier

#trigger delete client particulier de la commande

delimiter |
create trigger Delete_client_particulier
before delete on Client_particulier
for each row
begin
	delete from Commande where Commande.id_particulier = old.id_particulier;
end |



-- Trigger de Bicyclette

#trigger delete bicyclette des pieces et des commandes

delimiter |
create trigger Delete_bicyclette
before delete on Bicyclette
for each row
begin
	update Piece as p set p.id_bicyclette=null where p.id_bicyclette=old.id_bicyclette;
	if(old.num_commande is not null)
		then
			update Commande as c set c.quantite_bicyclettes_commande =  c.quantite_bicyclettes_commande - 1 where c.num_commande=old.num_commande;
	end if;
	
end |

# trigger ajout bicyclette dans une commande

delimiter |
create trigger MAJ_bicyclette
after update on Bicyclette
for each row
begin

	update Commande as c set c.quantite_bicyclettes_commande =  c.quantite_bicyclettes_commande + 1 where new.num_commande=c.num_commande;
	
end |

update Bicyclette as b set b.num_commande=1 where b.id_bicyclette='C102'; 

-- Trigger des pieces

# trigger des Delete pour les pieces des commandes

delimiter |
create trigger Delete_piece
after delete on Piece
for each row
begin
	if (old.num_commande is not null )
		then
		update Commande as c set  c.quantite_pieces_commande = c.quantite_pieces_commande - 1 where c.num_commande=old.num_commande;
	end if;
    
end |
drop trigger Delete_piece;


# trigger ajout piece dans une commande

delimiter |
create trigger MAJ_Piece
after update on Piece
for each row
begin

	update Commande as c set c.quantite_pieces_commande =  c.quantite_pieces_commande + 1 where new.num_commande=c.num_commande;
	
end |


#trigger fournir piece

delimiter |
create trigger fournir_pieces_Cadre
after insert on Piece
for each row
begin
	if (new.num_produit_piece='C32')
     then
		insert into Fournir values (new.id_produit_piece,123,new.num_produit_piece,'23:59:59');
	end if;
end |

delimiter |
create trigger fournir_pieces_Guidon
after insert on Piece
for each row
begin
	if (new.num_produit_piece='G7')
     then
		insert into Fournir values (new.id_produit_piece,145,new.num_produit_piece,'23:59:59');
	end if;
end |

delimiter |
create trigger fournir_pieces_Frein
after insert on Piece
for each row
begin
	if (new.num_produit_piece='F3')
     then
		insert into Fournir values (new.id_produit_piece,751,new.num_produit_piece,'23:59:59');
	end if;
end |

delimiter |
create trigger fournir_pieces_Selle
after insert on Piece
for each row
begin
	if (new.num_produit_piece='S88')
     then
		insert into Fournir values (new.id_produit_piece,452,new.num_produit_piece,'23:59:59');
	end if;
end |

delimiter |
create trigger fournir_pieces_Derailleur_Avant
after insert on Piece
for each row
begin
	if (new.num_produit_piece='CV133')
     then
		insert into Fournir values (new.id_produit_piece,512,new.num_produit_piece,'23:59:59');
	end if;
end |

delimiter |
create trigger fournir_pieces_Derailleur_Arriere
after insert on Piece
for each row
begin
	if (new.num_produit_piece='DR56')
     then
		insert into Fournir values (new.id_produit_piece,378,new.num_produit_piece,'23:59:59');
	end if;
end |

delimiter |
create trigger fournir_pieces_Roue_Avant
after insert on Piece
for each row
begin
	if (new.num_produit_piece='R45')
     then
		insert into Fournir values (new.id_produit_piece,512,new.num_produit_piece,'23:59:59');
	end if;
end |

delimiter |
create trigger fournir_pieces_Roue_Arriere
after insert on Piece
for each row
begin
	if (new.num_produit_piece='R46')
     then
		insert into Fournir values (new.id_produit_piece,512,new.num_produit_piece,'23:59:59');
	end if;
end |

delimiter |
create trigger fournir_pieces_Reflecteur
after insert on Piece
for each row
begin
	if (new.num_produit_piece='R02')
     then
		insert into Fournir values (new.id_produit_piece,512,new.num_produit_piece,'23:59:59');
	end if;
end |

delimiter |
create trigger fournir_pieces_Pedalier
after insert on Piece
for each row
begin
	if (new.num_produit_piece='P12')
     then
		insert into Fournir values (new.id_produit_piece,378,new.num_produit_piece,'23:59:59');
	end if;
end |

delimiter |
create trigger fournir_pieces_Ordinateur
after insert on Piece
for each row
begin
	if (new.num_produit_piece='O2')
     then
		insert into Fournir values (new.id_produit_piece,378,new.num_produit_piece,'23:59:59');
	end if;
end |

delimiter |
create trigger fournir_pieces_Panier
after insert on Piece
for each row
begin
	if (new.num_produit_piece='S01')
     then
		insert into Fournir values (new.id_produit_piece,378,new.num_produit_piece,'23:59:59');
	end if;
end |