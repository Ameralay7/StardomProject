using UnityEngine;
using System.Collections;

public class Movie {

	public string name;
	public string posterName;
	public string category;
	public string description;

	public int status;

	public string director;
	public string mainActor;
	public string mainActress;
	public string cameraMan;
	public string writer;
	public string fashionDesiger;
	public string producer;

	//temp
	public Texture directorPic;
	public Texture mainActorPic;
	public Texture mainActressPic;
	public Texture cameraManPic;
	public Texture writerPic;
	public Texture fashionDesigerPic;
	public Texture producerPic;

	public bool romanticScene;

	public Movie(){
		name = "none";
		posterName = "none";
		category = "none";
		description = "none";

		romanticScene = false;

	}

}
