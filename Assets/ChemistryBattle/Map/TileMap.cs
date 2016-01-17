using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour {
	
	public int size_x = 10;
	public int size_z = 5;
	public float tileSize = 1.0f;
	public int tileResolution;
	public Texture2D defaultTex;
	public Texture2D hitTex;
	public Texture2D missTex;
	public Texture2D[] terrainTiles;
	
	// Use this for initialization
	void Start () {
		BuildMesh();
		GameObject[] g =GameObject.FindGameObjectsWithTag ("Tube");
		for (int i=0; i<g.Length; i++) {
			MeshRenderer mesh_renderer = g[i].GetComponent<MeshRenderer>();
			Color old =mesh_renderer.sharedMaterials[0].color;
			Color newColor = new Color(old.r, old.b, old.g, 0.3f);          
			mesh_renderer.sharedMaterials[0].SetColor("_Color", newColor); 
		}
	}

	void BuildTexture() {
		int texWidth = size_x * tileResolution;
		int texHeight = size_z * tileResolution;
		Texture2D texture = new Texture2D(texWidth, texHeight);
		int i=0;
		for(int y=0; y < size_z; y++) {
			for(int x=0; x < size_x; x++) {
				Color[] p = defaultTex.GetPixels();
				if(terrainTiles[i]!=null){
				 	p = terrainTiles[i].GetPixels();
				}
				texture.SetPixels(x*tileResolution, y*tileResolution, tileResolution, tileResolution, p);
				i++;
			}
		}
		
		texture.filterMode = FilterMode.Point;
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.Apply();
		
		MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
		mesh_renderer.sharedMaterials[0].mainTexture = texture;
		
		Debug.Log ("Done Texture!");
	}
	
	public void BuildMesh() {
		int numTiles = size_x * size_z;
		int numTris = numTiles * 2;
		
		int vsize_x = size_x + 1;
		int vsize_z = size_z + 1;
		int numVerts = vsize_x * vsize_z;
		
		// Generate the mesh data
		Vector3[] vertices = new Vector3[ numVerts ];
		Vector3[] normals = new Vector3[numVerts];
		Vector2[] uv = new Vector2[numVerts];
		
		int[] triangles = new int[ numTris * 3 ];

		BoxCollider[] b = new BoxCollider[numTiles];

		int x, z;
		int tilenr = 0;
		for(z=0; z < vsize_z; z++) {
			for(x=0; x < vsize_x; x++) {
				vertices[ z * vsize_x + x ] = new Vector3( x*tileSize, 0, -z*tileSize );
				normals[ z * vsize_x + x ] = Vector3.up;
				uv[ z * vsize_x + x ] = new Vector2( (float)x / size_x, 1f - (float)z / size_z );
				//foreach(BoxCollider c in (BoxCollider[]) GameObject.Find("Tilemap").GetComponents<BoxCollider> ()) {
				//	DestroyImmediate(c);
				//}
				///create box colliders
				//b[tilenr] = (BoxCollider) GameObject.Find("Tilemap").AddComponent<BoxCollider>();
				//b[tilenr].center= new Vector3(x*(tileSize/2)+2,0,-z*(tileSize/2)-2 );
				//b[tilenr].size= new Vector3(tileSize,tileSize,tileSize);
				//tilenr++;
			}
		}
		
		for(z=0; z < size_z; z++) {
			for(x=0; x < size_x; x++) {
				int squareIndex = z * size_x + x;
				int triOffset = squareIndex * 6;
				triangles[triOffset + 0] = z * vsize_x + x + 		   0;
				triangles[triOffset + 2] = z * vsize_x + x + vsize_x + 0;
				triangles[triOffset + 1] = z * vsize_x + x + vsize_x + 1;
				
				triangles[triOffset + 3] = z * vsize_x + x + 		   0;
				triangles[triOffset + 5] = z * vsize_x + x + vsize_x + 1;
				triangles[triOffset + 4] = z * vsize_x + x + 		   1;

			}
		}

		// Create a new Mesh and populate with the data
		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;
		mesh.uv = uv;
		
		// Assign our mesh to our filter/renderer/collider
		MeshFilter mesh_filter = GetComponent<MeshFilter>();
		MeshCollider mesh_collider = GetComponent<MeshCollider>();
		
		mesh_filter.mesh = mesh;
		mesh_collider.sharedMesh = mesh;
		
		BuildTexture();
	}
	public int getPosOFTerrainTile(string name){
		int a=1;
		string afkorting="";
		for (int i=0; i<PeriodiekSysteem.Elementen.Count; i++) {
			if(PeriodiekSysteem.Elementen[i].Naam.ToUpper().Equals(name)){
				afkorting=PeriodiekSysteem.Elementen[i].Afkorting;
			}
		}
		if(afkorting.Equals("")){
			a=0;
		}else{
			for (int i=0; i<this.terrainTiles.Length; i++) {
				if (this.terrainTiles [i].name.ToUpper() != "NONE") {
					if (this.terrainTiles [i].name.ToUpper ().Equals(afkorting.ToUpper())) {
						return i + 3;
					}
				}
			}
		}
		return a;
	}
	public void checkCollision(){
		//check on tube collision
	}
	public void changeTile(int tileNumber, int status){
		MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
		Texture2D texture = (Texture2D) mesh_renderer.sharedMaterials[0].mainTexture;	
		int i = 0;
		bool check = false;
		int cy = 0;
		int cx = 0;
		for(int y=0; y < size_z; y++) {
			for(int x=0; x < size_x; x++) {
				if(i==tileNumber){
					check = true;
					cy=y;
					cx=x;
				}
				i++;
			}
		}
		Color[] p = defaultTex.GetPixels();
		if (status == 1) {
			p = hitTex.GetPixels ();
		} else if(status==2){
			p = missTex.GetPixels ();
		}
		if(check){
			texture.SetPixels(cx*tileResolution, cy*tileResolution, tileResolution, tileResolution, p);
			terrainTiles[tileNumber]=defaultTex;
		}
		texture.filterMode = FilterMode.Point;
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.Apply();
		mesh_renderer.sharedMaterials[0].mainTexture=texture;
	}
}
